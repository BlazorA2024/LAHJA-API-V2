using AutoMapper;
using Data;
using Dto;
using Dto.Plan;
using Entities;
using Microsoft.EntityFrameworkCore;
using Utilities;
using VM;

namespace Api.Seeds
{
    public static class DefaultPlansAndServices
    {



        public static async Task SeedAsync(DataContext context, IMapper mapper)
        {


            await context.PlanFeatures.ExecuteDeleteAsync();
            await context.Plans.ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            var planss = GetPlanCreateList(mapper);
            
          
                await context.Plans.AddRangeAsync(planss);
            foreach (var plan in planss)
            {   
                foreach (var planFeature in plan.PlanFeatures)
                {
                    planFeature.PlanId= plan.Id;
                }
                await context.PlanFeatures.AddRangeAsync(plan.PlanFeatures);
            }

            
           

            await context.SaveChangesAsync();



        }

    private static List<CategoryCreate> GetCategories()
        {
            return new List<CategoryCreate>
    {
        new CategoryCreate
        {
            Id = "1",
            Name = new Dictionary<string, string>
            {
                { "ar", "تحويل النص إلى صوت" },
                { "en", "Text-to-Speech" }
            },
            Description = new Dictionary<string, string>
            {
                { "ar", "تحويل النصوص المكتوبة إلى صوت باستخدام تقنيات الذكاء الاصطناعي المتقدمة." },
                { "en", "Convert written text to speech using advanced AI technologies." }
            },
            Active = true,
            Image = "/chatbot-03.png" // يمكن تغيير صورة البطاقة هنا
        },
        new CategoryCreate
        {
            Id = "2",
            Name = new Dictionary<string, string>
            {
                { "ar", "تحويل النص إلى لهجة" },
                { "en", "Text-to-Dialect" }
            },
            Description = new Dictionary<string, string>
            {
                { "ar", "تحويل النص إلى لهجة محددة بدقة عالية." },
                { "en", "Convert text into a specific dialect with high accuracy." }
            },
            Active = true,
            Image = "/chatbot-03.png" // يمكن تغيير صورة البطاقة هنا
        },
        new CategoryCreate
        {
            Id = "3",
            Name = new Dictionary<string, string>
            {
                { "ar", "روبوت تفاعلي (API)" },
                { "en", "Interactive Bot (API)" }
            },
            Description = new Dictionary<string, string>
            {
                { "ar", "دمج روبوت تفاعلي من خلال API للعديد من المهام." },
                { "en", "Integrate an interactive bot through API for various tasks." }
            },
            Active = true,
            Image = "/chatbot-03.png" // يمكن تغيير صورة البطاقة هنا
        }
    };
        }
     



     
    private static Dictionary<string, Dictionary<string, string>> Herotrial()
        {
             return  new()
             {
                 ["en"] = new()
                 {
                     ["Text1"] = "Try the power",
                     ["Text2"] = "AI Accent",
                     ["Description"] = "LAHJA platform provides a smart way to communicate with AI in your own dialect.",
                     ["ButtonLink"] = "Start your free trial"
                 },
                 ["ar"] = new()
                 {
                     ["Text1"] = "جرب قوة",
                     ["Text2"] = "لهجة AI",
                     ["Description"] = "توفر  منصة لهجة  طريقة ذكية للتواصل مع الذكاء الاصطناعي بلهجتك الخاصة.",
                     ["ButtonLink"] = "ابداء الاصدار التجريبي المجاني"
                 }
             };

    }
    private static List<FAQItemCreate> GetFAQItems()
        {
            return new List<FAQItemCreate>
    {
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "ما هو تحويل الصوت إلى نص؟" },
                { "en", "What is speech-to-text conversion?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "تحويل الصوت إلى نص هو عملية تحويل التسجيلات الصوتية إلى نصوص مكتوبة باستخدام تقنيات التعرف على الكلام. يتم استخدام هذه التقنية لتحويل المحادثات الصوتية، المقابلات، المحاضرات، والاجتماعات إلى نصوص يمكن معالجتها بسهولة." },
                { "en", "Speech-to-text conversion is the process of transforming audio recordings into written text using speech recognition technologies. This technology is used to transcribe conversations, interviews, lectures, and meetings into manageable text." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "هل يدعم نظام تحويل الصوت إلى نص اللغات واللهجات المختلفة؟" },
                { "en", "Does the speech-to-text system support different languages and dialects?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "نعم، يدعم النظام العديد من اللغات واللهجات، بما في ذلك اللهجات المحلية، مثل اللهجة النجدية. كما يمكن تخصيص النظام لتحسين الدقة في التعرف على لغات ولهجات معينة." },
                { "en", "Yes, the system supports various languages and dialects, including local accents like the Najdi dialect. The system can also be customized to improve accuracy for specific languages and dialects." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "كيف يمكنني استخدام خدمة تحويل النص إلى صوت؟" },
                { "en", "How can I use the text-to-speech service?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "يمكنك استخدام خدمة تحويل النص إلى صوت عن طريق إدخال النص المراد تحويله إلى النظام، الذي سيقوم بتوليد صوت بشري طبيعي وفقًا للنص. يمكن تخصيص الصوت والنبرة حسب احتياجاتك." },
                { "en", "You can use the text-to-speech service by entering the text you want to convert into the system, which will generate a natural human-like voice based on the text. The voice and tone can be customized according to your needs." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "ما هي أنواع النصوص التي يمكن تحويلها إلى صوت؟" },
                { "en", "What types of text can be converted to speech?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "يمكن تحويل النصوص القصيرة، الطويلة، أو المعقدة إلى صوت. على سبيل المثال، يمكن تحويل المقالات، الكتب، أو حتى النصوص التفاعلية في التطبيقات." },
                { "en", "Short, long, or complex texts can be converted to speech. For example, articles, books, or even interactive texts in applications can be processed." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "هل يمكن تخصيص الصوت الذي يُنتج عند تحويل النص إلى صوت؟" },
                { "en", "Can the voice generated in text-to-speech be customized?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "نعم، يمكنك تخصيص الصوت من حيث النبرة والسرعة. يمكنك أيضًا اختيار الصوت (ذكر أو أنثى) الذي يناسب تطبيقك." },
                { "en", "Yes, you can customize the voice in terms of tone and speed. You can also choose the voice (male or female) that suits your application." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "هل يمكن تحويل النص إلى لهجة معينة؟" },
                { "en", "Can text be converted to a specific dialect?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "نعم، نقدم خدمة تحويل النصوص إلى لهجات محلية مثل اللهجة النجدية، الحجازية، وغيرها. يمكن أيضًا تخصيص النبرة والسرعة لتناسب الاحتياجات المحلية." },
                { "en", "Yes, we offer text conversion services to local dialects such as the Najdi, Hijazi, and others. The tone and speed can also be tailored to meet local needs." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "ما هو استخدام خدمة الدردشة الفورية؟" },
                { "en", "What is the use of the instant chat service?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "خدمة الدردشة الفورية هي نظام يعتمد على الذكاء الاصطناعي للتفاعل مع المستخدمين بشكل فوري، والإجابة على استفساراتهم. تستخدم هذه الخدمة في دعم العملاء، المساعدات الشخصية، والتفاعل مع المستخدمين في التطبيقات المختلفة." },
                { "en", "The instant chat service is an AI-powered system that interacts with users in real time, answering their inquiries. It is used in customer support, personal assistants, and user interaction in various applications." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "هل يمكن دمج هذه الخدمات مع التطبيقات الخاصة بي؟" },
                { "en", "Can these services be integrated with my applications?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "نعم، نقدم API مفتوح للتكامل مع الأنظمة والتطبيقات الأخرى، مما يتيح لك دمج خدمات تحويل الصوت إلى نص، تحويل النص إلى صوت، تحويل النص إلى لهجة، والدردشة الفورية بسهولة." },
                { "en", "Yes, we provide an open API for integration with other systems and applications, allowing you to seamlessly integrate services like speech-to-text, text-to-speech, text-to-dialect conversion, and instant chat." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "هل يحتاج النظام إلى اتصال بالإنترنت؟" },
                { "en", "Does the system require an internet connection?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "نعم، بعض الخدمات قد تتطلب اتصالاً بالإنترنت، خاصة عندما يتم معالجة البيانات على الخوادم. ولكن هناك أيضًا خيارات لتشغيل بعض الخدمات محليًا في بيئات لا تدعم الاتصال المستمر بالإنترنت." },
                { "en", "Yes, some services may require an internet connection, especially when processing data on servers. However, there are also options for running certain services locally in environments that do not support continuous internet connectivity." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "كيف يمكنني تخصيص الخدمة لتناسب احتياجاتي؟" },
                { "en", "How can I customize the service to meet my needs?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "يمكنك تخصيص الخدمة من خلال تحديد إعدادات الصوت، النبرة، السرعة، اللهجات، بالإضافة إلى تكامل الأنظمة عبر API. إذا كانت لديك متطلبات خاصة، يمكننا العمل معك لتوفير حل مخصص يناسب احتياجاتك." },
                { "en", "You can customize the service by configuring voice settings, tone, speed, and dialects, as well as system integration via API. If you have specific requirements, we can work with you to provide a tailored solution." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "هل يمكنني استخدام الخدمة في التطبيقات متعددة المنصات؟" },
                { "en", "Can I use the service on multiple platforms?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "نعم، يمكن استخدام هذه الخدمات عبر مختلف المنصات مثل الهواتف المحمولة (Android و iOS)، وأجهزة الكمبيوتر، ويمكن أيضًا دمجها في تطبيقات الويب والتطبيقات التي تعمل في الخلفية." },
                { "en", "Yes, these services can be used across various platforms such as mobile phones (Android and iOS), computers, and can also be integrated into web applications and background processes." }
            }
        },
        new FAQItemCreate
        {
            Question = new Dictionary<string, string>
            {
                { "ar", "ما هي تكلفة استخدام هذه الخدمات؟" },
                { "en", "What is the cost of using these services?" }
            },
            Answer = new Dictionary<string, string>
            {
                { "ar", "تعتمد تكلفة الخدمة على الخطة التي تختارها وعدد الطلبات التي تحتاج إليها. يمكنك التواصل معنا للحصول على تفاصيل حول الأسعار وفقًا لاحتياجاتك." },
                { "en", "The cost of the service depends on the plan you choose and the number of requests you need. You can contact us for details about pricing based on your requirements." }
            }
        }
    };
        }


        static List<PlanFeatureCreate> GetPlanFeatureCreateFree()
            {



                var planFeatures = new List<PlanFeatureCreate>
                      {
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "AI Models" },
                                    { "ar", "عدد النماذج AI" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "3" },
                                    { "ar", "3" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Requests" },
                                    { "ar", "الطلبات" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "1,000 requests" },
                                    { "ar", "1,000 طلب" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Processor" },
                                    { "ar", "المعالج" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Shared" },
                                    { "ar", "مشترك" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "RAM" },
                                    { "ar", "الذاكرة العشوائية" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "CPU 2 GB" },
                                    { "ar", "CPU 2 جيجابايت" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Speed" },
                                    { "ar", "السرعة" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "2 pre/Second" },
                                    { "ar", "2 pre/Second" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Support" },
                                    { "ar", "الدعم" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "No" },
                                    { "ar", "لا" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Customization" },
                                    { "ar", "تخصيص" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "No" },
                                    { "ar", "لا" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "API" },
                                    { "ar", "API" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "No" },
                                    { "ar", "لا" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Space" },
                                    { "ar", "Space" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "1" },
                                    { "ar", "1" }
                                }
                            }
                        };



                return planFeatures;

            }



        static List<PlanFeatureCreate> GetPlanFeatureCreateStandard()
        {



            var planFeatures = new List<PlanFeatureCreate>
                      {
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "AI Models" },
                                    { "ar", "عدد النماذج AI" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "3" },
                                    { "ar", "3" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Requests" },
                                    { "ar", "الطلبات" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "10,000 " },
                                    { "ar", "10,000 " }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Processor" },
                                    { "ar","   المعالج" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "  CPU 2 GB" },
                                    { "ar", "CPU 2 جيجابايت" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "RAM" },
                                    { "ar", "الذاكرة العشوائية" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "CPU 2 GB" },
                                    { "ar", "CPU 2 جيجابايت" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Speed" },
                                    { "ar", "السرعة" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "1 pre/Second" },
                                    { "ar", "1 pre/Second" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Support" },
                                    { "ar", "الدعم" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "No" },
                                    { "ar", "لا" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Customization" },
                                    { "ar", "تخصيص" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "No" },
                                    { "ar", "لا" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "API" },
                                    { "ar", "API" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Yes" },
                                    { "ar", "نعم" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Space" },
                                    { "ar", "Space" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "3" },
                                    { "ar", "3" }
                                }
                            },
                             new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Scalability  " },
                                    { "ar", ":قابلية التوسيع" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Twice amonth" },
                                    { "ar", "مرتين شهريا" }
                                }
                            }
                        };



            return planFeatures;

        }



        static List<PlanFeatureCreate> GetPlanFeatureCreateProfessional()
        {



            var planFeatures = new List<PlanFeatureCreate>
                      {
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "AI Models" },
                                    { "ar", "عدد النماذج AI" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "12" },
                                    { "ar", "12" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Requests" },
                                    { "ar", "الطلبات" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "100,000 " },
                                    { "ar", "100,000 " }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Processor" },
                                    { "ar","   المعالج" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "  CPU 4 GB" },
                                    { "ar", "CPU 4 جيجابايت" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "RAM" },
                                    { "ar", "الذاكرة العشوائية" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "CPU 8 GB" },
                                    { "ar", "CPU 8 جيجابايت" }
                                }
                            },
                            new PlanFeatureCreate 
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Speed" },
                                    { "ar", "السرعة" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "0.5  pre/Second" },
                                    { "ar", "0.5  pre/Second" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Support" },
                                    { "ar", "الدعم" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Yse" },
                                    { "ar", "نعم" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Customization" },
                                    { "ar", "تخصيص" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Yse" },
                                    { "ar", "نعم" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "API" },
                                    { "ar", "API" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Yes" },
                                    { "ar", "نعم" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Space" },
                                    { "ar", "Space" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "10" },
                                    { "ar", "10" }
                                }
                            },
                             new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Scalability  " },
                                    { "ar", ":قابلية التوسيع" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Unlimited" },
                                    { "ar", "غير محدد" }
                                }
                            }
                        };



            return planFeatures;

        }

        static List<PlanFeatureCreate> GetPlanFeatureCreateEnterprise()
        {



            var planFeatures = new List<PlanFeatureCreate>
                      {
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "AI Models" },
                                    { "ar", "عدد النماذج AI" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "12" },
                                    { "ar", "12" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Requests" },
                                    { "ar", "الطلبات" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Unlimited " },
                                    { "ar", "غير محدد " }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Processor" },
                                    { "ar","   المعالج" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", " Unlimited" },
                                    { "ar", "غير محدد" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "RAM" },
                                    { "ar", "الذاكرة العشوائية" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Unlimited" },
                                    { "ar", "غير محدد" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Speed" },
                                    { "ar", "السرعة" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "0.5  pre/Second" },
                                    { "ar", "0.5  pre/Second" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Support" },
                                    { "ar", "الدعم" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Yse" },
                                    { "ar", "نعم" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Customization" },
                                    { "ar", "تخصيص" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Yse" },
                                    { "ar", "نعم" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "API" },
                                    { "ar", "API" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Yes" },
                                    { "ar", "نعم" }
                                }
                            },
                            new PlanFeatureCreate
                            {
                                Name = new Dictionary<string, string>
                                {
                                    { "en", "Space" },
                                    { "ar", "Space" }
                                },
                                Description = new Dictionary<string, string>
                                {
                                    { "en", "Unlimited" },
                                    { "ar", "غير محدد" }
                                }
                            },
                            
                        };



            return planFeatures;

        }

        public static List<Plan> GetPlanCreateList(IMapper mapper)
        {








            var cplans = new List<PlanCreate>()
            {

               new PlanCreate()
               {
                    Id = "price_1QlfhDB7xaGIYuCb1DRshr5b",
                    
                    ProductId = "prod_Rex80Tw6GABc7M",
                   Name=new Dictionary<string, string>()
                   {
                                     { "en", "Free" },
                                    { "ar", "Free" }
                   }

                  ,
                   Description=new Dictionary<string, string>()
                   {
                       // حط الوصف 
                          { "en", "Free" },
                        { "ar", "خطة اشتراك أساسية" }
                   },
                   Price=0.0m,
                   Amount=0,
                   Features=GetPlanFeatureCreateFree()
               }
               ,
               new PlanCreate()
               {
                    Id = "price_1Qlg3OB7xaGIYuCb95XiW7fe",

                    ProductId = "prod_Rex97sXfeIXXMK",
                   Name=new Dictionary<string, string>()
                   {
                                     { "en", "Standard" },
                                    { "ar", "Standard" }
                   }

                  ,
                   Description=new Dictionary<string, string>()
                   {
                       // حط الوصف 
                          { "en", "Intermediate subscription plan" },
                        { "ar", "خطة اشتراك متوسطة" }
                   },
                   Price=150m,
                   Amount=150,
                   Features=GetPlanFeatureCreateStandard()
               },
                new PlanCreate()
               {
                     Id = "price_1QldGsB7xaGIYuCbCp59S5DF",

                    ProductId = "prod_RexBhUTUZKzz6V",
                   Name=new Dictionary<string, string>()
                   {
                                     { "en", "Professional" },
                                    { "ar", "Professional" }
                   }

                  ,
                   Description=new Dictionary<string, string>()
                   {
                       // حط الوصف 
                          { "en", "Professional subscription plan" },
                        { "ar", "خطة اشتراك احترافية" }
                   },
                   Price=250m,
                   Amount=250.0,
                   Features=GetPlanFeatureCreateProfessional()
               },

                new PlanCreate()
               {
                     Id = "price_1QldJZB7xaGIYuCbHbiaMbFp",

                    ProductId = "prod_RexER4jurUaCJw",
                   Name=new Dictionary<string, string>()
                   {
                                     { "en", "Enterprise" },
                                    { "ar", "Enterprise" }
                   }

                  ,
                   Description=new Dictionary<string, string>()
                   {
                       // حط الوصف 
                          { "en", "Advanced subscription plan for enterprises" },
                        { "ar", "خطة اشتراك متقدمة للمؤسسات" }
                   },
                   Price=1000m,
                   Amount=1000,
                   Features=GetPlanFeatureCreateEnterprise()
               }


            };
            // ضيف بقية الخطط والمعلومات 


            var plans = mapper.Map<List<Plan>>( cplans );

            





            return plans;
        }

  private static Service[] GetServices(string modelAiId)
        {
            Service[] services = [
            new Service() { Name = "Text to text", Token = "bearer",AbsolutePath="t2t" ,ModelAiId=modelAiId},
                    new Service() { Name = "Text To Speech",AbsolutePath="t2speech", Token = "bearer",ModelAiId=modelAiId },
                    new Service() { Name = "VoiceBot",AbsolutePath = "speaker", Token = "bearer" , ModelAiId = modelAiId},
                    ];

            return services;
        }

        private static List<Plan> GetPlans()
        {

            List<Plan> plans =
            [
                 new()
                {
                    Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
                    BillingPeriod = "month",
                    //NumberRequests = 10,
                    ProductId = "prod_RL4cPSzDwjdQyh",
                    ProductName = "Free",
                    Description="DDDFGFGF",
                    Amount = 0,
                    Images=null,
                    Active=true,
                    UpdatedAt=DateTime.Today,
                    CreatedAt=DateTime.Today
                   
                   

        //public required long NumberRequests { get; set; }

 
                }
               

            ];

            return plans;

        }

    }
}