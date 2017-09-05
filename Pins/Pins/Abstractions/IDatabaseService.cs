using SQLite.Net;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pins.Abstractions
{
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
