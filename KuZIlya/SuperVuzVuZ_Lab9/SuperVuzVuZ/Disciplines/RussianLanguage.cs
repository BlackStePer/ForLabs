using SuperVuzVuZ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVuzVuZ.Disciplines {
    /// <summary>
    /// Русский язык — это восточнославянский язык, национальный язык русского народа и один из крупнейших языков мира. Он является государственным языком Российской Федерации, одним из государственных языков Беларуси и официальным языком ООН.
    /// </summary>
    internal class RussianLanguage : Discipline, IHaveAngryTeacher {
        public RussianLanguage() : base("Русский =(") => SetBribe(15000);
        public override Exam exam { get; set; } = new Exam(101);
    }
}
