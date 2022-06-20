using System.Collections.Generic;

namespace ProyectoPruebaAleix.Models
{
    public class ModalInformationModel
    {
        public string Id_modal { get; set; }
        public string Titulo { get; set; }
        public List<InputModal> Inputs { get; set; }
        public string Id_Button { get; set; }
        public string Name_Button { get; set; }
        public string Id_Form { get; set; }

        public class InputModal
        {
            public string Id_input { get; set; }
            public string Name_input { get; set; }
            public string Type_input { get; set; }
            public string Label { get; set; }
            public int Max_length { get; set; }

            public InputModal(string id_input, string name_input, string type_input, string label, int max_lenght)
            {
                Id_input = id_input;
                Name_input = name_input;
                Type_input = type_input;
                Label = label;
                Max_length = max_lenght;
            }
        }
    }
}
