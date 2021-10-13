var Carro = new Object();

Carro.marca = "Fiat";
Carro.modelo = "Uno";
Carro.cor = "Vermelho";
Carro.ligado = false;

Carro.partida = function(){
    Carro.ligado = true;
}

Carro.partida();
console.log(Carro)