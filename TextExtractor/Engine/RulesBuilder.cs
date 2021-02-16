using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextExtractor.Engine.Locators;
using TextExtractor.Engine.Matchers;
using TextExtractor.Exceptions;

namespace TextExtractor.Engine
{
    public static class Consts
    {
        public static string[] RuleProperties => new string[] { "Name", "Location" };
        public static string[] LocationProperties => new string[] { "Type", "MatchConditions" };
    }

    public static class RulesBuilder
    {

        public static IEnumerable<ILocator> GetRules(string textRules)
        {
            var rules = new ConcurrentBag<ILocator>();
            var errors = new ConcurrentBag<string>();
            var tokens = JArray.Parse(textRules);

            CancellationTokenSource cts = new CancellationTokenSource();

            // Use ParallelOptions instance to store the CancellationToken
            var po = new ParallelOptions
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            try
            {
                Parallel.ForEach(tokens, po, token =>
                {
                    if (token.Type == JTokenType.Object)
                    {
                        var validationErrors = ValidateSchema(token, Consts.RuleProperties);
                        ThrowValidationErrors(errors, po, validationErrors);

                        var location = token["Location"];
                        validationErrors = ValidateSchema(location, Consts.LocationProperties);
                        ThrowValidationErrors(errors, po, validationErrors);

                        rules.Add(CreateLocator(location, token.Value<string>("Name")));
                    }
                    else
                    {
                        errors.Add($"Bad Rule (Object Expected): { token }");
                        po.CancellationToken.ThrowIfCancellationRequested();
                    }
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }

            return rules;
        }

        private static void ThrowValidationErrors(ConcurrentBag<string> errors,
            ParallelOptions po, List<string> validationErrors)
        {
            if (validationErrors.Count > 0)
            {
                validationErrors.ForEach(e => errors.Add(e));
                po.CancellationToken.ThrowIfCancellationRequested();
            }
        }

        private static List<string> ValidateSchema(JToken token, string[] properties)
        {
            var errors = new List<string>();
            foreach (var prop in properties)
            {
                if (token[prop] == null)
                {
                    errors.Add($"Missing Property: {prop} in Rule: { token }");
                }
            }
            return errors;
        }

        private static ILocator CreateLocator(JToken data, string name)
        {
            var type = data.Value<string>("Type");
            switch (type.ToLower())
            {
                case "after":
                    return new After()
                    {
                        Name = name,
                        Token = new Entities.Token(data["Token"].Value<string>("Value"),
                                                    data["Token"].Value<bool>("Fuzzy")),
                        MatchingConditions = CreateMatchConditions(data.Value<JToken>("Match"))
                    };
                case "between":
                    return new Between()
                    {
                        Name = name,
                        StartToken = new Entities.Token(data["StartToken"].Value<string>("Value"),
                                                    data["StartToken"].Value<bool>("Fuzzy")),
                        EndToken = new Entities.Token(data["EndToken"].Value<string>("Value"),
                                                    data["EndToken"].Value<bool>("Fuzzy")),
                        MatchingConditions = CreateMatchConditions(data.Value<JToken>("Match"))
                    };
                case "before":
                    return new Before()
                    {
                        Name = name,
                        Token = new Entities.Token(data["Token"].Value<string>("Value"),
                                                    data["Token"].Value<bool>("Fuzzy")),
                        MatchingConditions = CreateMatchConditions(data.Value<JToken>("Match"))
                    };
                default:
                    throw new LocatorNotImplementedException(type);
            }
        }

        private static IMatcher CreateMatchConditions(JToken condition)
        {
            var matchConditions = new List<IMatcher>();

                var type = condition.Value<string>("Type");
                switch (type.ToLower())
                {
                    case "any":
                        return new BasicMatcher();
                        break;
                    default:
                        throw new MatchConditionNotImplementedException(type);
                }
            
        }
    }
}
