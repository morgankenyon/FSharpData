namespace FSharpData.Db

open System.Threading.Tasks

type IQuestionRepository =
    interface
        abstract member GetQuestion : int -> Question Task
        abstract member GetQuestions : unit -> Question list Task
        abstract member CreateQuestion : Question -> Question
    end


type QuestionRepository(context: FSharpDataContext) =
    interface IQuestionRepository with
        member this.GetQuestion id =
            let q = query {
                for question in context.Questions do
                    where (question.Id = id)
                    select question
                    exactlyOne
            }
            let asyncQuery = async {
                return q
            }
            Async.StartAsTask(asyncQuery)
        member this.GetQuestions () =
            let query = async {
                return context.Questions
                    |> Seq.toList
            }
            Async.StartAsTask(query)
            //|> Async.
            //query {
            //    for question in context.Questions do 
            //        select question
            //} |> Seq.toList

        member this.CreateQuestion entity =
            context.Questions.Add(entity) |> ignore
            context.SaveChanges true |> ignore
            entity