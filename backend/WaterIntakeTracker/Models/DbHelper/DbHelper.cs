using WaterIntakeTracker.DataLayer;
using WaterIntakeTracker.DataLayer.Models;

namespace WaterIntakeTracker.Models.DbHelper
{
    public class DbHelper
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DbHelper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //GET
        public List<TestModel> GetTestModels(){
            var model = new List<TestModel>();
            var datalist = _applicationDbContext.TestModels.ToList();
            datalist.ForEach(row => model.Add(new TestModel(){
                Name = row.Name,
                Id = row.Id,
            }));
            return model;
        }

        //GET by id
        public TestModel GetTestModelsById(int id){
            var row = _applicationDbContext.TestModels.Where(x=>x.Id.Equals(id)).FirstOrDefault();
            return new TestModel(){
                Name = row.Name,
                Id = row.Id,
            };
        }

        /// <summary>
        /// POST , PUT
        /// </summary>
        /// <param name="model"></param> <summary>
        /// It serves for post, put and update
        /// </summary>
        /// <param name="model"></param>
        public void SaveData(TestModel model)
        {
            Test record = new Test();
            
            if(model.Id>0)
            {
                //PUT - update
                record = _applicationDbContext.TestModels.Where(t=>t.Id == model.Id).FirstOrDefault();
                              
                if (record!=null){
                    record.Name = model.Name;
                }
                //Post
                else{
                    record.Name = model.Name;
                    record.Id = model.Id;
                    _applicationDbContext.TestModels.Add(record);
                }
                _applicationDbContext.SaveChanges();
            }
            
        }

        //DELETE
        public void DeleteData(int id){
            var record = _applicationDbContext.TestModels.Where(t=>t.Id == id).FirstOrDefault();
               if(record!=null){
                    _applicationDbContext.TestModels.Remove(record);
                    _applicationDbContext.SaveChanges();
               }
        }

    }
}