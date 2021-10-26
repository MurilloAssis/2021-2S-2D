var qualquer = new Object();

var pessoa = new Object();
pessoa.nome = "Murillo";
pessoa.sobrenome = "Assis";
pessoa.sexo = "Masculino";
pessoa.idade = 16;
pessoa.altura = 1.70;
pessoa.peso = 95;
pessoa.andando = false;
pessoa.caminhouQuantosMetros = 0;

pessoa.fazerAniversario = function(){
    pessoa.idade = pessoa.idade + 1;
}

pessoa.andar = function(metros){
    pessoa.andando = true;
    pessoa.caminhouQuantosMetros = pessoa.caminhouQuantosMetros + metros;
}

pessoa.parar = function(){
    pessoa.andando = false;
}

pessoa.nomeCompleto = function(){
    return pessoa.nome + " " + pessoa.sobrenome;
}

pessoa.mostrarIdade = function(){
    return "Olá! Eu tenho " + pessoa.idade + " anos!";
}

pessoa.mostrarPeso = function(){
    return "Meu peso é " + pessoa.peso + "Kg";
}

pessoa.mostrarAltura = function(){
    return "Minha altura é " + pessoa.altura + "M";
}

console.log(pessoa.nomeCompleto());
console.log(pessoa.mostrarIdade());
console.log(pessoa.mostrarPeso());
console.log(pessoa.mostrarAltura());

pessoa.fazerAniversario();
pessoa.fazerAniversario();
pessoa.fazerAniversario();
console.log(pessoa.mostrarIdade());

pessoa.andar(100)
pessoa.andar(50)
pessoa.andar(30)
console.log("A pessoa ainda está andando?")
if (pessoa.andando == true) {
    console.log("Sim, ainda está andando")
}
else{
    console.log("Não, não está andando")
}

pessoa.parar();
console.log("A pessoa ainda está andando?")
if (pessoa.andando == true) {
    console.log("Sim, ainda está andando")
}
else{
    console.log("Não, não está andando")
}



pessoa.apresentacao = function(){
    let metro = "metros";
    let ano = "anos";
    let pronome = "o";
    if (pessoa.sexo == "Feminino") {
        pronome = "a"
    }
    if (pessoa.idade == 1) {
        ano = "ano"
    }
    if (pessoa.caminhouQuantosMetros == 1) {
       metro = "metro"
    }
    return `Olá, eu sou ${pronome} ${pessoa.nomeCompleto()}, tenho ${pessoa.idade} ${ano}, ${pessoa.mostrarAltura()}, ${pessoa.mostrarPeso()} e, só hoje, eu já caminhei ${pessoa.caminhouQuantosMetros} ${metro}!`;
}

console.log(pessoa.apresentacao())