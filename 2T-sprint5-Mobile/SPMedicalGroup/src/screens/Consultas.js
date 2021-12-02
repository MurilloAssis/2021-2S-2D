import React, {Component} from 'react';

import api from '../services/api';

import { TouchableOpacity} from 'react-native-gesture-handler';

import AsyncStorage from '@react-native-async-storage/async-storage';
import { View, Text } from 'react-native';

export default class Consultas extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas: []
        };
    }

    // buscarConsultas = async () => {
    //     const xambers = await AsyncStorage.getItem('userToken')
    //     const resposta = await api.get('/Consultas/Lista/Minhas', {
    //         headers:{
    //             authorization: 'Bearer ' + xambers 
    //         }
    //     });

    //     const dadosDaApi = resposta.data;

    //     this.setState({listaConsultas: dadosDaApi})
    // }
    // componentDidMount(){
    //     this.buscarConsultas();
    // }

    render(){
        return(
            <View>
                <Text>Consultas</Text>
            </View>
        )
    }
}