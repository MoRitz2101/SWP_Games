using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_Games
{
    public interface ICommand
    {
        void Install();
        void Start();
        void Close();
        void Remove();
        void Update();
        
    }
}
