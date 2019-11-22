using projectForWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectForWork.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        //Index sayfası 
        public ActionResult Index()
        {
            databaseContext dbCont = new databaseContext();
            List<questions> Questions = dbCont.Questions.ToList();
            int id = 1;
            List<questions> firstQuestion = (from q in dbCont.Questions where q.Id == id select q).ToList();



            return View(firstQuestion);
        }
        //Bir sonraki soruyu getirme kısmı
        public JsonResult getNextQuestion(int id)
        {
            databaseContext dbCont = new databaseContext();
            List<questions> Questions = dbCont.Questions.ToList();

            List<questions> nextQuestion = (from q in dbCont.Questions where q.Id == id select q).ToList();

            return Json(nextQuestion, JsonRequestBehavior.AllowGet);
        }
        //Tamamının cevaplanması ardından sonucu döndürecek olan method
        [HttpPost]
        public JsonResult getResult(int[] arr)
        {
            databaseContext dbCont = new databaseContext();
            List<variables> Variables = dbCont.Variables.ToList();
            var result = new List<result>();
            result resl = new result();

            foreach (var item in Variables)
            {
                resl.variableName = item.variable_name;


                     

                    resl.variableValue = ((arr[0] * item.quest_1_effect) / 100 + (arr[1] * item.quest_2_effect) / 100 +
                        (arr[2] * item.quest_3_effect) / 100 + (arr[3] * item.quest_4_effect) / 100 +
                        (arr[4] * item.quest_5_effect) / 100 +
                        (arr[5] * item.quest_6_effect) / 100 + (arr[6] * item.quest_7_effect) / 100 +
                        (arr[7] * item.quest_8_effect) / 100 + (arr[8] * item.quest_9_effect) / 100 +
                        (arr[9] * item.quest_10_effect) / 100);

               
                //result.Add(resl);
                //result.Insert(inc,resl);
                result.Add(new result() { variableName = resl.variableName, variableValue = resl.variableValue });

            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

    }
}