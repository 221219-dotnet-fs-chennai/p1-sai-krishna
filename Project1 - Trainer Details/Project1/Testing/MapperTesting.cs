using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using EF = Data__FluentApi.Entities;

namespace Testing
{
    public class MapperTesting
    {
        internal class TestMapping
        {
            [Test]
            public void TestTrainerMapper1()
            {
                //arrange
                Models.Trainer trainerData = new Models.Trainer();
                //act
                var trainerEF = Mapper.TrainerMapper(trainerData);
                //assert
                Assert.AreEqual(trainerEF.GetType(), typeof(EF.Trainer));
            }

            [Test]
            public void TestTrainerMapper2()
            {
                //arrange
                EF.Trainer trainerEF = new EF.Trainer();
                //act
                var trainerData = Mapper.TrainerMapper(trainerEF);
                //assert
                Assert.AreEqual(trainerData.GetType(), typeof(Models.Trainer));
               
            }

            [Test]
            public void TestSkillMapper()
            {
                //arrange
                EF.Skill skillEF = new EF.Skill();
                //act
                var skillData = Mapper.SkillMapper(skillEF);
                //assert
                Assert.AreEqual(skillData.GetType(), typeof(Models.Skill));
            }

            [Test]
            public void TestAchivementMapper()
            {
                //arrange
                EF.Achivement achivementEF = new EF.Achivement();
                //act
                var achivementData = Mapper.AchivementMapper( achivementEF);
                //assert
                Assert.AreEqual(achivementData.GetType(), typeof(Models.Achivements));
            }

            [Test]
            public void TestEducationMapper()
            {
                //arrange
                EF.Education eduEF = new EF.Education();
                //act
                var educationData = Mapper.EducationMapper(eduEF);
                //assert
                Assert.AreEqual(educationData.GetType(), typeof(Models.Education));
            }

            [Test]
            public void TestExperienceMapper()
            {
                //arrange
                EF.Experience exEF = new EF.Experience();
                //act
                var experienceData = Mapper.ExperienceMapper(exEF);
                //assert
                Assert.AreEqual(experienceData.GetType(), typeof(Models.Experience));
            }
        }
    }
}
