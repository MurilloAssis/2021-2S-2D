import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Switch, Redirect} from 'react-router-dom'

import './index.css';

import Home from './pages/home/App';
import TiposEventos from './pages/tiposEventos/tiposEventos';
import NotFound from './pages/NotFound/notFound';

import reportWebVitals from './reportWebVitals';


/*
var x = document.getElementById('root');
console.log(x.baseURI )

var dominio = 'http://localhost:3000/'
switch (x.baseURI) {
  case dominio:
    ReactDOM.render(
  
      <React.StrictMode>
        <Home />
      </React.StrictMode>,
      document.getElementById('root'),
    );
    break;

  case dominio + 'tiposEventos':
    ReactDOM.render(
  
      <React.StrictMode>
        <TiposEventos />
      </React.StrictMode>,
      document.getElementById('root'),
    );
    break;
  default:
    ReactDOM.render(
  
      <React.StrictMode>
        <NotFound />
      </React.StrictMode>,
      document.getElementById('root'),
    );
    break;
}
*/

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/tiposEventos" component={TiposEventos} />
        {/*<Route path="*" component={NotFound} />*/}
        <Route path="/notFound" component={NotFound} />
        <Redirect to="/notFound"/>
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
reportWebVitals(console.log);
