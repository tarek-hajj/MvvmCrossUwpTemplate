using MvvmCross.ViewModels;
using MvxUwpTemplate.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvxUwpTemplate.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<GuestBookViewModel>();
        }
    }
}
