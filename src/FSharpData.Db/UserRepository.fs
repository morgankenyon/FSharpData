namespace FSharpData.Db

open System.Threading.Tasks

type IUserRepository =
    interface
        abstract member GetUser : int -> User Task 
        abstract member GetUserQuery : int -> User
        abstract member GetUsers : unit -> User list Task
        abstract member CreateUser : User -> Task<User>
    end


type UserRepository(context: FSharpDataContext) =
    interface IUserRepository with
        member this.GetUser id =
            let query = context.Users 
                        |> Seq.tryFind (fun q -> q.Id = id)

            let user = match query with
            | Some i -> i
            | None -> null

            let asyncQuery = async {
                return user
            }
            Async.StartAsTask(asyncQuery)
        member this.GetUserQuery id =
            query {
                for user in context.Users do
                    where (user.Id = id)
                    select user
                    exactlyOneOrDefault
            }
        member this.GetUsers () =
            let query = async {
                return context.Users
                    |> Seq.toList
            }
            Async.StartAsTask(query)
        member this.CreateUser entity =
            let query = async {
                context.Users.Add(entity) |> ignore
                context.SaveChanges true |> ignore
                return entity            
            }
            Async.StartAsTask(query)
