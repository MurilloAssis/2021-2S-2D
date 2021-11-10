import { Component } from "react";
import { Link } from 'react-router-dom';
import axios from 'axios'
import '../../assets/css/login.css';
import logo from "../../assets/img/logo_spmedgroup_v1 1.png"



export default class Login extends Component {

  constructor(props) {
    super(props)
    this.state = {
      email: '',
      senha : '',
      erroMensagem : '',
      isLoading : false
    };
  }

  efetuaLogin(event) {
    event.PreventDefault();

    this.setState({isLoading : true, erroMensagem : ''})

    axios.post()

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
              <form>
                <div className="item">
                  <input
                    className="input__login"
                    placeholder="E-mail"
                    type="text"
                    name="username"
                    id="login__email"
                  />
                </div>
                <div className="item">
                  <input
                    className="input__login"
                    placeholder="Senha"
                    type="password"
                    name="password"
                    id="login__senha"
                  />
                </div>
                <div className="item">
                  <button className="btn btn__login" id="btn__login">
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