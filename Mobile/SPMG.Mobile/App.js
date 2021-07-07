import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from './src/services/api';

export default class App extends Component
{
   constructor(props)
   {
     super(proprs);
     this.shouldComponentUpdate =
     {
       listaConsultas: [ ],
     };
   }
  
   //puxa da api e passa para o listaConsultas
   buscarConsultas = async () => 
   {
     const resposta = await api.get('/consultas');
     const dadosdaApi = resposta.data;
     this.setState({ listaConsultas : dadosdaApi });
   };

   // realiza a chamada da api
   componentDidMount()
   {
     this.buscarConsultas();
   }
  
   // renderiza a página
   render() { 
     return (
        <View style={ styles.container }>
        <Text>{'Consultas'.toUpperCase()}</Text>

          <View>
            <FlatList
              contentContainerStyle={styles.mainBodyConteudo}
              data={this.state.listaConsultas}
              keyExtractor = {(item) => item.idConsulta}
              renderItem={this.renderizaItem}
            />
          </View>
        </View>
      );
   }

   renderizaItem = ({item}) => (
     <View style={styles.flatItemLinha}>
        <View>
          <Text> {item.idConsulta} </Text>
          <Text> {item.descricao} </Text>
          <Text> {item.dataConsulta} </Text>
        </View>
     </View>
   );
   
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: 'gray',
    alignItems: 'center',
    justifyContent: 'center',
  },

  //conteudo da lista

  mainBodyConteudo: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50,
  },
  
  flatItemLinha: {
    flexDirection: 'row',
    borderBottomWidth: 0.9,
    borderBottomColor: 'blue',
  }
});
