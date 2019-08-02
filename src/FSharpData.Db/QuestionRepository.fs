namespace FSharpData.Db

open System.Threading.Tasks

type IQuestionRepository =
    interface
        abstract member GetQuestion : int -> Question Task
        abstract member GetQuestionOption : int -> Question option Task
        abstract member GetQuestions : unit -> Question list Task
        abstract member CreateQuestion : Question -> Question Task
    end


type QuestionRepository(context: FSharpDataContext) =
    interface IQuestionRepository with
        member this.GetQuestion id =
            let q = query {
                for question in context.Questions do
                    where (question.Id = id)
                    select question
                    exactlyOneOrDefault
            }
            let asyncQuery = async {
                return q
            }
            Async.StartAsTask(asyncQuery)
        member this.GetQuestionOption id =
            let asyncQuery = async {
                return context.Questions 
                |> Seq.tryFind (fun q -> q.Id = id)
            }
            Async.StartAsTask(asyncQuery)
        member this.GetQuestions () =
            let query = async {
                return context.Questions
                    |> Seq.toList
            }
            Async.StartAsTask(query)

        member this.CreateQuestion entity =
            let query = async {
                context.Questions.Add(entity) |> ignore
                context.SaveChanges true |> ignore
                return entity            
            }
            Async.StartAsTask(query)