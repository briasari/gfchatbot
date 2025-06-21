using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gfchatbot
{
    internal class ConversationManager
    {
        private static readonly Random rand = new Random();

        public static string ProcessMessage(string input)
        {
            var data = GameData.CurrentSave;
            string msg = input.ToLower();

            bool isApology = msg.Contains("sorry") || msg.Contains("apologize") || msg.Contains("forgive me") || msg.Contains("my bad");
            bool isExcuse = msg.Contains("forgot") || msg.Contains("busy") || msg.Contains("not my fault");
            bool isDismissive = msg.Contains("calm down") || msg.Contains("overreacting") || msg.Contains("relax");
            bool isFlirty = msg.Contains("love") || msg.Contains("miss") || msg.Contains("baby") || msg.Contains("babe");

            //detailed checks based on scenario
            bool talksAboutAnniversary = msg.Contains("anniversary") || msg.Contains("date") || msg.Contains("remember");

            bool talksAboutSister = msg.Contains("sister") || msg.Contains("hate her") || msg.Contains("avoid") || msg.Contains("skipping");

            bool talksAboutClingy = msg.Contains("clingy") || msg.Contains("behind my back") || msg.Contains("called me") || msg.Contains("sam");
            

            string response = "";

            if (data.ForgivenessCooldown > 0)
                data.ForgivenessCooldown--;

            if (isApology)
            {
                if (data.AngerLevel >= 3)
                    response = Pick(new[] { "oh NOW you're sorry?", "you always say that after the damage is done." });
                else if (data.AngerLevel == 2)
                    response = "fine. just… don’t let it happen again.";
                else
                    response = "thank you. really.";

                data.AngerLevel = Math.Max(0, data.AngerLevel - 1);
                data.RelationshipPoints = Math.Min(5, data.RelationshipPoints + 1);
            }
            else if (isExcuse)
            {
                response = Pick(new[] {
            "convenient how that always happens to you.",
            "you really think that excuses it?"
        });

                data.AngerLevel = Math.Min(5, data.AngerLevel + 1);
                data.ForgivenessCooldown = 2;
            }
            else if (isDismissive)
            {
                response = "wow. gaslight me harder.";
                data.AngerLevel = Math.Min(5, data.AngerLevel + 2);
                data.ForgivenessCooldown = 3;
            }
            else if (isFlirty)
            {
                if (data.AngerLevel >= 3)
                    response = "don't flirt your way out of this.";
                else
                {
                    response = Pick(new[] {
                "you’re lucky you’re cute.",
                "don’t think that line saves you, but it’s working."
            });
                    data.RelationshipPoints = Math.Min(5, data.RelationshipPoints + 1);
                    data.AngerLevel = Math.Max(0, data.AngerLevel - 1);
                }
            }
            else
            {
                //scenario-specific reactions
                switch (data.ScenarioIndex)
                {
                    case 0: // forgot anniversary
                        if (talksAboutAnniversary)
                        {
                            if (data.AngerLevel >= 4) response = "you forgot again? that's really hurtful.";
                            else if (data.AngerLevel >= 2) response = "please don't let this happen again.";
                            else response = "thanks for remembering. it means a lot.";
                        }
                        else
                        {
                            response = DefaultResponse(data.ScenarioIndex, data.AngerLevel);
                        }
                        break;

                    case 1: // hates sister
                        if (talksAboutSister)
                        {
                            if (data.AngerLevel >= 4) response = "you better show up, or else.";
                            else if (data.AngerLevel >= 2) response = "i don't want to argue about this. just come.";
                            else response = "fine, but next time don't make it such a big deal.";
                        }
                        else
                        {
                            response = DefaultResponse(data.ScenarioIndex, data.AngerLevel);
                        }
                        break;

                    case 2: // called clingy behind back

                        if (talksAboutClingy)
                        {
                            bool deniesClingy = msg.Contains("no") || msg.Contains("not true") || msg.Contains("never") || msg.Contains("don't") || msg.Contains("didn't") || msg.Contains("deny");
                            if (deniesClingy)
                            {
                                if (data.AngerLevel >= 4)
                                    response = "denying it won't help, you know.";
                                else if (data.AngerLevel >= 2)
                                    response = "i want to believe you, but it's hard.";
                                else
                                    response = "okay, i hope you're telling the truth.";
                            }
                            else
                            {
                                if (data.AngerLevel >= 4)
                                    response = "how could you say that about me?";
                                else if (data.AngerLevel >= 2)
                                    response = "please explain yourself.";
                                else
                                    response = "i want to believe you.";
                            }
                        }
                        else
                        {
                            response = DefaultResponse(data.ScenarioIndex, data.AngerLevel);
                        }
                        break;


                    default:
                        response = DefaultResponse(data.ScenarioIndex, data.AngerLevel);
                        break;
                }
            }

            //camp values
            data.AngerLevel = Clamp(data.AngerLevel, 0, 5);
            data.RelationshipPoints = Clamp(data.RelationshipPoints, 0, 5);

            //endings check
            if (data.AngerLevel >= 5 && data.ForgivenessCooldown > 0)
            {
                GameData.SaveGame();
                return "[BLOCKED] you really don’t get it. bye.";
            }

            if (data.RelationshipPoints >= 5 && data.AngerLevel <= 1)
            {
                GameData.SaveGame();
                return "[GOOD ENDING] okay... you're forgiven. don't screw it up again.";
            }

            GameData.SaveGame();
            return response;
        }


        private static string Pick(string[] options)
        {
            return options[rand.Next(options.Length)];
        }

        private static string DefaultResponse(int scenario, int anger)
        {
            string[][] fallback = new string[][]
            {
            //scenario 0: forgot anniversary
            new string[] {
                "still can't believe you forgot...",
                "you really made me feel small today.",
                "i don’t even know what to say anymore."
            },
            //scenario 1: hate her sister
            new string[] {
                "you said you’d try. you lied.",
                "so it’s always going to be like this?",
                "i just wanted one peaceful night."
            },
            //scenario 2: called her clingy
            new string[] {
                "you talk behind my back and expect hugs?",
                "how would you feel if i said that about you?",
                "i trusted you. you made me look stupid."
            }
            };

            int s = Clamp(scenario, 0, fallback.Length - 1);
            int a = Clamp(anger, 0, fallback[s].Length - 1);
            return fallback[s][a];
        }

        private static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}