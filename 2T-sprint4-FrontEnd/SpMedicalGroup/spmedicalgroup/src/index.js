import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,

} from 'react-router-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import Login from './pages/login/login';
import Administrador from './pages/Administrador/adm';


const routing = (
  <Router>
    <div>
      <Switch>
        <Route path="/login" component={Login}/>
        <Route path="/listarEventos" component={Administrador}/>
      </Switch>
    </div>
  </Router>
) 

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
