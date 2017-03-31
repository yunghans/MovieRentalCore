using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Data
{
    public static class DBInitializer
    {
        public static void Initialize(MovieRentalContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
