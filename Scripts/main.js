import React from "react";
import ReactDom from "react-dom";

class Layout extends React.Component {
    render () {
        const name = "kitten";
        return (
            <h1>It works, {name}</h1>
            );
    }
}

const app = document.getElementById('app');
console.log("FJERNEMEG");
ReactDom.render(<Layout/>, app);