using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SegundoParcial_AdrianMendez.UI.Validaciones {
    public class CamposObligatoriosRule : ValidationRule{

        public CamposObligatoriosRule() { }

        public override ValidationResult Validate(object value , CultureInfo cultureInfo) {


            try {

                if (string.IsNullOrWhiteSpace(((string) value))) {
                    return new ValidationResult(false , $"Este campo no puede estar vació");
                }

            } catch (System.Exception e) {

                return new ValidationResult(false , $"error de formato.\n" + e.Message);
            }

            return ValidationResult.ValidResult;

        }
    }
}
