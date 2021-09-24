using senai_hroads_tarde_webapi.Contexts;
using senai_hroads_tarde_webapi.Domains;
using senai_hroads_tarde_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_hroads_tarde_webapi.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(byte id, Personagem persoAtt)
        {
            Personagem persoBuscado = BuscarPorId(id);

            if (persoAtt.NomePersonagem != null || persoAtt.IdClasse > 0 || persoAtt.DataCriacao != null || persoAtt.DataAtualizacao != null || persoAtt.CapacidadeMaxVida > 0 || persoAtt.CapacidadeMaxMana > 0)
            {
                persoBuscado.NomePersonagem = persoAtt.NomePersonagem;
                persoBuscado.IdClasse = persoAtt.IdClasse;
                persoBuscado.DataCriacao = persoAtt.DataCriacao;
                persoBuscado.DataAtualizacao = persoAtt.DataAtualizacao;
                persoBuscado.CapacidadeMaxVida = persoAtt.CapacidadeMaxVida;
                persoBuscado.CapacidadeMaxMana = persoAtt.CapacidadeMaxMana;

                ctx.Update(persoBuscado);

                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(byte id)
        {
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPerso)
        {
            ctx.Personagems.Add(novoPerso);

            ctx.SaveChanges();
        }

        public void Deletar(byte id)
        {
            ctx.Personagems.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagems.ToList();
        }
    }
}
