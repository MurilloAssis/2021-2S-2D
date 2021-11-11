import { useEffect, useState } from "react"
import '../../assets/css/style.css'
import '../../assets/css/consultasAdm.css'
import Header from "../../components/Header/header"
import Footer from "../../components/Footer/footer"
import axios from "axios"

export default function administrador(){

    const [listaConsultas, setListaConsultas] = useState( [] )
    function consultasAdm(){
        axios()
    }
   
        return (
            <div>

            
            <Header></Header>
            <main className="conteudoPrincipal">
                <section className="conteudoPrincipal-cadastro">


                    <section className="container" id="conteudoPrincipal-cadastro">
                        <h2 className="conteudoPrincipal-cadastro-titulo">
                            Cadastrar Consulta
                        </h2>
                        <form>
                            <div className="container">
                                <select name="" id="">
                                    <option value="#">Escolha um paciente</option>
                                    <option value="#">Saulo</option>
                                    <option value="#">Lucas</option>
                                </select>

                                <select name="" id="">
                                    <option value="">Escolha um médico</option>
                                    <option value="">Gustavo</option>
                                    <option value="">João</option>
                                </select>

                                <input type="datetime-local" name="" id="" />
                                <button
                                    className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro"
                                >
                                    Cadastrar
                                </button>
                            </div>
                        </form>
                    </section>

                    <h2 className="conteudoPrincipal-cadastro-titulo">Consultas</h2>
                    <div className="container" id="conteudoPrincipal-lista">
                        <table id="tabela-lista">
                            <thead>
                                <tr>
                                    <th>Descrição</th>
                                    <th>Paciente</th>
                                    <th>Médico</th>
                                    <th>Data</th>
                                    <th>Instituição</th>
                                </tr>
                            </thead>

                            <tbody id="tabela-lista-corpo">

                            </tbody>
                        </table>
                    </div>
                </section>
            </main>
            <Footer></Footer>
            </div>
        )
    
}