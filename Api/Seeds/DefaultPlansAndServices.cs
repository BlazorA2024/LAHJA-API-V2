using AutoMapper;
using Data;
using Dto;
using Dto.Plan;
using Entities;
using Microsoft.EntityFrameworkCore;
using Utilities;

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