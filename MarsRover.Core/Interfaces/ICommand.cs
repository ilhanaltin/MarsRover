using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// execute rover rotation/movement
        /// </summary>
        public void Execute();
    }
}
