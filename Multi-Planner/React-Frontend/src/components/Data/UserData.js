import React from "react";

function getData(){
    let data = sessionStorage.getItem('FacebookData');
    data = JSON.parse(data);
    return data;
}

export const GetUserData = () => {
    return getData();
}