export default function Mapa(){

    requestMap = () => {
        fetch("http://localhost:5000/api/Localizacao")
        .then(resposta => resposta.json())
        .then(itens => montarMapa(itens))
        .catch(erro => console.log(erro))
    }

    montarMapa = () => {
        
    }

    return(
        <div id="map"></div>
    )
}