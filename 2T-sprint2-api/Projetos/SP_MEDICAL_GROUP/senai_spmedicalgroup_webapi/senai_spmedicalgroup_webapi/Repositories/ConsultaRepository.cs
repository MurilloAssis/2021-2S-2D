using Microsoft.EntityFrameworkCore;
using senai_spmedicalgroup_webapi.Contexts;
using senai_spmedicalgroup_webapi.Domains;
using senai_spmedicalgroup_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedicalgroup_webapi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();
        public void AlterarDescricao(Consultum consultaAtt, int id)
        {
            Consultum consultaBuscado = BuscarPorId(id);
            if (consultaAtt.DescricaoConsulta != null)
            {
                consultaBuscado.DescricaoConsulta = consultaAtt.DescricaoConsulta;

                ctx.Consulta.Update(consultaBuscado);

                ctx.SaveChanges();
            };

        }
       
        public void CadastrarConsulta(Consultum novaConsulta)
        {
            if (novaConsulta.DescricaoConsulta == null)
            {
                novaConsulta.DescricaoConsulta = "A Consulta foi agendada!";

                ctx.Consulta.Add(novaConsulta);

                ctx.SaveChanges();
            }
        }

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(u => u.IdConsulta == id);
        }

        public void CancelarConsulta(int Id)
        {
            Consultum consultaBuscada = BuscarPorId(Id);
            
            consultaBuscada.IdSituacao = 3;
            consultaBuscada.DescricaoConsulta = "Consulta Cancelada!";

            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
            
        }

        public List<Consultum> ListarConsultaMedico(int id)
        {
            Medico medico = ctx.Medicos.FirstOrDefault(u => u.IdUsuario == id);

            int idMedico = medico.IdMedico;

            return ctx.Consulta
                            .Where(c => c.IdMedico == idMedico)
                            .IgnoreAutoIncludes()
                            .Include(c => c.IdMedicoNavigation)
                            .ToList();
        }

        public List<Consultum> ListarConsultaPaciente(int id)
        {
            Paciente paciente = ctx.Pacientes.FirstOrDefault(u => u.IdUsuario == id);

            int idPaciente = paciente.IdPaciente;
            return ctx.Consulta
                            .Where(c => c.IdConsulta == idPaciente)
                            .Include(c => c.IdMedicoNavigation)
                            .ToList();
                            

        }

        public List<Consultum> ListarTodas()
        {
            return ctx.Consulta.ToList();
        }
    }
}
