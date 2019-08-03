namespace FSharpData.Db

open System.Threading.Tasks

type IQuestionRepository =
    interface
        abstract member GetQuestion : int -> Question Task 
        abstract member GetQuestionQuery : int -> Question
        abstract member GetQuestions : unit -> Question list Task
        abstract member CreateQuestion : Question -> Task<Question>
    end


type QuestionRepository(context: FSharpDataContext) =
    interface IQuestionRepository with
        member this.GetQuestion id =
            let query = context.Questions 
                        |> Seq.tryFind (fun q -> q.Id = id)

            let question = match query with
            | Some i -> i
            | None -> null

            let asyncQuery = async {
                return question
            }
            Async.StartAsTask(asyncQuery)
        member this.GetQuestionQuery id =
            query {
                for question in context.Questions do
                    where (question.Id = id)
                    select question
                    exactlyOneOrDefault
            }
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
