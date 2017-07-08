using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CSharpProjectV3.Models;

namespace CSharpProjectV3.DAL
{
    //Initializer to drop database if model changes.  Once completely firm on parameters, alter to not continually drop database.

    public class DaylilyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DaylilyContext>
    {

        //Provided seed data.  Would need to be altered later if model changes to doubles and preselected colors.  See Models/Daylily.cs for notes.

        protected override void Seed(DaylilyContext context)
        {
            var daylilies = new List<Daylily>
            {
                new Daylily { Name="Little Business", Color="Red", Height=15, BloomSize=3},
                new Daylily { Name="Big Top", Color="Salmon", Height=28, BloomSize=8},
                new Daylily { Name="Byzantine Emperor", Color="Dark Red", Height=30, BloomSize=6},
                new Daylily { Name="Double Daffy", Color="Yellow", Height=28, BloomSize=4},
                new Daylily { Name="Mauna Loa", Color="Gold", Height=22, BloomSize=5},
                new Daylily { Name="Plum Candy", Color="Peach", Height=24, BloomSize=4},
            };
            daylilies.ForEach(d => context.Daylilies.Add(d));
            context.SaveChanges();
            
            
            //base.Seed(context);
        }

    }
}