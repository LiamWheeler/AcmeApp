const heading = document.getElementById('heading');
const input = document.getElementById('input')
const button = document.getElementById('button')
const lists = document.getElementsByTagName('li')


heading.addEventListener('click',()=>{
heading.style.color='red';
});

button.addEventListener('click',()=>{
 heading.style.color = input.value;
});

for( i = 0; i < lists.length; i++){
    lists[i].style.color = 'orange';
}

const listsItems = document.querySelectorAll('li:nth-child(even)');
console.log(listsItems);
console.log(listsItems.length)
for( i = 0; i< listsItems.length; i++){
    listsItems[i].style.color = 'lightgreen';
}

const placeholder = document.getElementById('placeholder');
const submit = document.getElementById('submit');
const list = document.getElementById('list');

//submit.addEventListener('click',() =>{
//    placeholder.style.color='goldenrod';
//    placeholder.textContent = input.value;
//})
 

submit.addEventListener('click', () =>{
    placeholder.style.color = 'goldenrod';
    placeholder.textContent = '<li>${input.value}</li>';
    list.innerHTML = ' <li>${input.value}</li>';
})