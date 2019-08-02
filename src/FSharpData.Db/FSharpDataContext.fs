namespace FSharpData.Db

open Microsoft.EntityFrameworkCore


type FSharpDataContext(options : DbContextOptions<FSharpDataContext>) =
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable questions : DbSet<Question>
    member x.Questions
        with get() = x.questions
        and set v = x.questions <- v

    [<DefaultValue>]
    val mutable users : DbSet<User>
    member x.Users
        with get() = x.users
        and set v = x.users <- v

