import React from "react";

function getData(){
    let data = sessionStorage.getItem('FacebookData');
    if(typeof(data) ===  'object'){
        JSON.parse(data);
    }
    return data;
}

export const GetUserData = () => {
    return getData();
}