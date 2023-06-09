using System.Text.RegularExpressions;
using Back_End_ER02.Interfaces;

namespace Back_End_ER02.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? cnpj { get; set; }
        public string? razaoSocial { get; set; }

        public override float CalcularImposto(float rendimento)
        {
            if (rendimento <= 3000 )
            {   
               return rendimento * 0.03f;
                
            } else if (rendimento > 3000 && rendimento <= 6000 )
            {
                return rendimento * 0.05f;

            } else if (rendimento > 6000 && rendimento <= 10000 )
            {
                return rendimento * 0.07f;

            } else 
            {
                return rendimento * 0.09f;
            } 
        }

        // internal void ValidarCnpj()
        // {
        //     throw new NotImplementedException();
        // }

        public bool ValidarCnpj(string cnpj)
        {   // 00.476.645/0001-03 ==> 18 digitos
            // 00476645000103 ==> 14 digitos

           bool retornoCnpjValido = Regex.IsMatch(cnpj, @"^(\d{14})|(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})$");

           if (retornoCnpjValido)
           {
                string subStringCnpj14 = cnpj.Substring(8, 4);

                if (subStringCnpj14 == "0001")
                {
                    return true;
                }
    
           }

           string subStringCnpj18 = cnpj.Substring (11, 4);

                if (subStringCnpj18 == "0001")
                {
                    return true;
                }

            return false;
        
          
        }
    }
}