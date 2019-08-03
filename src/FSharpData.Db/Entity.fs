namespace FSharpData.Db

open System


type [<AllowNullLiteral>] Question() =
    [<DefaultValue>]
    val mutable private id : int
    member this.Id 
        with get() = this.id
        and set(value) = this.id  <- value
        
    [<DefaultValue>]
    val mutable private title : string
    member this.Title
        with get() = this.title
        and set value = this.title <- value
                
    [<DefaultValue>]
    val mutable private text : string
    member this.Text
        with get() = this.text
        and set value = this.text <- value
        
    [<DefaultValue>]
    val mutable private userId : int
    member this.UserId 
        with get() = this.userId
        and set value = this.userId <- value
        
    [<DefaultValue>]
    val mutable private user : User
    member this.User 
        with get() = this.user
        and set value = this.user <- value
        
    [<DefaultValue>]
    val mutable private createdDate : DateTime
    member this.CreatedDate 
        with get() = this.createdDate
        and set value = this.createdDate <- value
        
    [<DefaultValue>]
    val mutable private updatedDate : DateTime
    member this.UpdatedDate 
        with get() = this.updatedDate
        and set value = this.updatedDate <- value

and [<AllowNullLiteral>] User() =
    [<DefaultValue>]
    val mutable private id : int
    member this.Id 
        with get() = this.id
        and set(value) = this.id  <- value
    
    [<DefaultValue>]
    val mutable private email : string
    member this.Email 
        with get() = this.email
        and set(value) = this.email  <- value
    
    [<DefaultValue>]
    val mutable private username : string
    member this.Username 
        with get() = this.username
        and set(value) = this.username  <- value
    
    [<DefaultValue>]
    val mutable private questions : Question list
    member this.Questions 
        with get() = this.questions
        and set(value) = this.questions  <- value
    
    [<DefaultValue>]
    val mutable private createdDate : DateTime
    member this.CreatedDate 
        with get() = this.createdDate
        and set value = this.createdDate <- value
    
    [<DefaultValue>]
    val mutable private updatedDate : DateTime
    member this.UpdatedDate 
        with get() = this.updatedDate
        and set value = this.updatedDate <- value

