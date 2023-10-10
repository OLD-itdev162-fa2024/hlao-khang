using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence{
  public class Seed{
    public static void SeedData(DataContext context){
      if(!context.Posts.Any()){
        var Posts = new List<Post>
        {
          new Post{
            Title = "First Post",
            Body = "Lorem ipasdfdasfda dsfassdafasd. asdfasdjfsakljfla pokh dh dskjfdhvncjxvbkcn bvkl.",
            Date = DateTime.Now.AddDays(-10)
            },
          new Post{
            Title = "Second Post",
            Body = "Lorfdasdfas dfjsalfk dsaldj lkfasdjbkcn bvkl.",
            Date = DateTime.Now.AddDays(-7)
            },
          new Post{
            Title = "Third Post",
            Body = " Impredakdfasj fdsaklj dklfa sdklvcmzx,cmnvcxkpsl f,w kc, op opj",
            Date = DateTime.Now.AddDays(-4),
            }
        };

        context.Posts.AddRange(Posts);
        context.SaveChanges();
      }
    }
  }
}