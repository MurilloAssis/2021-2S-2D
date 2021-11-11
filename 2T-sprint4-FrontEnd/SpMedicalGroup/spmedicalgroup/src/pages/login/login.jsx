import { Component } from "react";
import { Link } from 'react-router-dom';
import axios from 'axios'
import { parseJwt, usuarioAutenticado } from "../../services/auth";
import '../../assets/css/login.css';
import logo from "../../assets/img/logo_spmedgroup_v1 1.png"



export default class Login extends Component {

  constructor(props) {
    super(props);
    this.state = {
      email: 'Rafaela@email.com',
      senha : '1234',
      erroMensagem : '',
      isLoading : false
    };
  }

  efetuaLogin = (event) => {
    event.preventDefault();

    this.setState({ erroMensagem: '', isLoading: true });

    axios.post('http://localhost:5000/api/Login', {
      emailUsuario : this.state.email,
      senhaUsuario : this.state.senha
    })

    .then((response) => {
      if(response.status === 200){
        localStorage.setItem('usuario-login', response.data.token)
        this.setState({isLoading : false})

      

        if(parseJwt().role === '1'){
          this.props.history.push('/listarconsultas')

        }
      }
    })

  }

  atualizaStateCampo = (campo) => {
    this.setState({[campo.target.name] : campo.target.value})

    console.log(campo.target.value)
  }
  render() {
    return (
      <div>
        <section className="container-login flex">
          <div className="img__login"><div className="img__overlay"></div></div>

          <div className="item__login">
            <div className="row">
              <div className="item">
                <img src={logo} className="icone__login" alt="logo do SpMedical" />
              </div>
              <div className="item" id="item__title">
                <p className="text__login" id="item__description">
                  Bem-vindo! Faça login para acessar sua conta.
                </p>
              </div>
              <form onSubmit={this.efetuaLogin}>
                <div className="item">
                  <input
                    className="input__login"
                    placeholder="E-mail"
                    value={this.state.email}
                    onChange={this.atualizaStateCampo}
                    type="text"
                    name="email"
                    id="login__email"
                  />
                </div>
                <div className="item">
                  <input
                    className="input__login"
                    placeholder="Senha"
                    value={this.state.senha}
                    onChange={this.atualizaStateCampo}
                    type="password"
                    name="senha"
                    id="login__senha"
                  />
                </div>
                <div className="item">
                  <button type="submit" className="btn btn__login" id="btn__login">
                    Login
                  </button>
                </div>
              </form>
            </div>
          </div>
        </section>
      </div>
    )
  }
}