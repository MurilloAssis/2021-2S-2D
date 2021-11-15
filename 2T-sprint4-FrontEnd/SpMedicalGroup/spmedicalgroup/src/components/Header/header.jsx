import '../../assets/css/style.css'
import '../../assets/css/consultasAdm.css'
import '../../assets/css/login.css';
import logo from "../../assets/img/logo_spmedgroup_v1 1.png"
import userimg from "../../assets/img/user_img.png"
import { Link } from 'react-router-dom';

export default function header (){
        return (
            <header>
                <div className="container container_header">
                    <img className="logo" src={logo} alt="Logo SP Medical" />
                    <div className="space_left">
                        <nav className="links_uteis">
                            <Link to="/#">Inicio</Link>
                            <Link to="/#">Consulta</Link>
                            <Link to="/#">Equipe</Link>
                            <Link to="/#">Contate-nos</Link>

                        </nav>
                        <div className="img_config">
                            <img className="user_img logo" src={userimg} alt="" />
                            <i className="fas fa-cog"></i>
                        </div>
                    </div>
                </div>
            </header>
        )
}