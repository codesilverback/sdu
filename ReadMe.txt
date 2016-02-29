

What works:
Data Repositories all work with pipe delimited, comma delimited, or space delimited files.  Writing these files assumes that we place our data in quotation marks.  (Otherwise Linus Van Pelt would be a bad entry.)
Inserts and reads work.
Duplicate writes create duplicate rows.
If we have a write collision, the second writer waits until the first finishes.
Unit test coverage is solid on the repos.  Integration tests exist to verify that we can read and write appropriately from actual files.

What's not done, sketchy or poorly thought through:
Dependency Injection.  I got lost in the wilds of WebApi dependency injection with Windsor.  I brought in some cargo-cult code from blogs to get it compiling but it is barely working.  
I really wanted to use IRepository<T>.  I’m not sure that was a good idea for this project. 
What we have is very "poor man's DI."  Constructor injection works, but I would rather it use configurations to determine which repository to provide at runtime.  This involves overriding default factories and I just ran out of time.  Our one controller just hardcodes the path of its repo.  That's just nasty.  
There's a distinction between data models "Person" and the models that WebApi uses.  I created a SDU domain project but never used it.  If we think of SDU.Data as being akin to some database repository, it doesn't seem right to pass its objects up to the application layer.  The fact that these models are identical confuses the distinction between data objects and domain objects.  Our WebApi objects enforce validation rules.  There’s an argument that such validation should be in place at the repo level too.  
There's basically no front end.  Gets work fine in the browser but posting JSON up from the browser isn't tested at all.  Our API doesn't provide pretty error messages.  It doesn't massage data (e.g. change FEMALE to female).


