import React from 'react';

const Person = (props) => {
    return (
        <div>
            <h1> My name is {props.name}, I am {props.age} years old. My pets name is {props.pet}</h1>
        </div>
    )
}

export default Person;