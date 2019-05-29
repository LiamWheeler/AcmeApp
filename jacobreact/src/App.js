import React from 'react';
import './App.css';
import Person from './Person';

class App extends React.Component {
  state = {
    persons: [
      {name: "Liam", age: 25, pet: "Doggo"},
      {name: "Warren", age: 29, pet: "Catto"},
      {name: "Dave", age: 20, pet:"Fisho"}
    ]
  }

  render(){
    return(
      <div>
        <Person name = {this.state.persons[0].name} age = {this.state.persons[0].age} pet = {this.state.persons[0].pet}/>
        <Person name = {this.state.persons[1].name} age = {this.state.persons[1].age} pet = {this.state.persons[1].pet}/>
        <Person name = {this.state.persons[2].name} age = {this.state.persons[2].age} pet = {this.state.persons[2].pet}/>
      </div>
    )
  }
}

export default App;
