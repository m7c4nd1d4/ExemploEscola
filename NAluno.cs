using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ExemploEscola
{
    class NAluno
    {
        private static List<Aluno> alunos = new List<Aluno>();
        public static void Inserir(Aluno t)
        {
            Abrir();
            alunos.Add(t);
            Salvar();
        }
        public static List<Aluno> Listar()
        {
            Abrir();
            return alunos;
        }
        public static void Atualizar(Aluno t)
        {
            Abrir();
            foreach (Aluno obj in alunos)
                if (obj.Id == t.Id)
                {
                    obj.Nome = t.Nome;
                    obj.Matricula = t.Matricula;
                    obj.Email = t.Email;
                }
            Salvar();
        }
        public static void Excluir(Aluno t)
        {
            Abrir();
            Aluno x = null;
            foreach (Aluno obj in alunos)
                if (obj.Id == t.Id) x = obj;
            if (x != null) alunos.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
                f = new StreamReader("./alunos.xml");
                alunos = (List<Aluno>)xml.Deserialize(f);
            }
            catch
            {
                alunos = new List<Aluno>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
            StreamWriter f = new StreamWriter("./alunos.xml", false);
            xml.Serialize(f, alunos);
            f.Close();
        }
    }
}
