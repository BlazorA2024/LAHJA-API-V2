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
                                    { "en", "2 GB" },
                                    { "ar", "2 جيجابايت" }
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

  





  public static List<Plan> GetPlanCreateList(IMapper mapper)
        {








            var cplans = new List<PlanCreate>()
            {

               new PlanCreate()
               {
                   Name=new Dictionary<string, string>()
                   {
                                     { "en", "Free" },
                                    { "ar", "مجاني" }
                   }

                  ,
                   Description=new Dictionary<string, string>()
                   {
                       // حط الوصف 
                          { "en", "Free" },
                        { "ar", "مجاني" }
                   },
                   Price=0.0m,
                   Amount=0,
                   Features=GetPlanFeatureCreateFree()
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
                    new Service() { Name = "Audio",AbsolutePath="t2speech", Token = "bearer",ModelAiId=modelAiId },
                    new Service() { Name = "Speaker",AbsolutePath = "speaker", Token = "bearer" , ModelAiId = modelAiId},
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