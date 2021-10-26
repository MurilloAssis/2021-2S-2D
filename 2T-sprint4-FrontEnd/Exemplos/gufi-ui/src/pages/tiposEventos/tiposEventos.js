import {Component} from 'react';

class TiposEventos extends Component{
    constructor(props){
        super(props)
        this.state = {
            titulo : '',
            listaTiposEventos : [],
            idTipoEventoAlterado : ''
        };
    };

    buscarTiposEventos(){
        console.log("Agora vamos fazer a chamada para a api")
    }

    atualizaEstadoTitulo = async (event) => {
        await this.setState({titulo: event.target.value})
        console.log(this.state.titulo)
    }

    cadastrarTipoEvento = (event) => {
        event.preventDefault();

        if (this.state.idTipoEventoAlterado !== 0) {
            fetch('http://localhost:5000/api/TipoEventos' + this.state.idTipoEventoAlterado, {
                method : 'PUT',
                body : JSON.stringify({tituloTipoEvento : this.state.titulo}),
                headers : {
                    "Content-type" : "application/json"
                }
            })

            .then(resposta => {
                if (resposta.status === 204) {
                    console.log(
                        'O tipo de Evento ' + this.state.idTipoEventoAlterado + 'Foi atualizado!'
                    )
                }
            })
        }

        fetch("http://localhost:5000/api/TipoEventos", {
            method: 'POST',
            body: JSON.stringify({tituloTipoEvento : this.state.titulo}),
            headers:{ "Content-Type" : "application/json"}
        }).then(console.log("Tipo de Evento Cadastrado"))

        .then(this.buscarTiposEventos())
        .then(this.setState({titulo : ''}))
        .catch(erro => console.log(erro))

    }
    componentDidMount(){
        this.buscarTiposEventos();
        
        fetch('http://localhost:5000/api/TipoEvento')

        .then(resposta => resposta.json())

        .then(dados => this.setState({listaTiposEventos: dados}))
    };

    render(){
        return(
            <div className="App">
                
                <main className="App-header">
                    {/*Lista de tipos eventos */}
                    <section>
                        <h2>Lista de tipos de eventos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaTiposEventos.map((tipoEvento) => {
                                        return(
                                            <tr key={tipoEvento.idTipoEvento}>
                                                <td>{tipoEvento.idTipoEvento}</td>
                                                <td>{tipoEvento.tituloTipoEvento}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                    <section>
                        <h2>Cadastro tipo de evento</h2>
                        <form onSubmit={this.cadastrarTipoEvento}>
                            <div>
                                <input type="text" value={this.state.titulo} 
                                
                                placeholder="Titulo do tipo de evento"
                                
                                onChange={this.atualizaEstadoTitulo}
                                />
                                <button type="submit" >Cadastrar</button>
                            </div>
                        </form>
                    </section>
                    {/* Cadastro de tipos de eventos */}
                </main>
            </div>
        )
    }
};



export default TiposEventos
