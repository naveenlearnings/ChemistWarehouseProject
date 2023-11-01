import React, { useEffect, useState } from "react";
import Header  from "../Header";
export default function Layout(props) {
return (
    <React.Fragment>
        <Header/>
        {props.children}
    </React.Fragment>
)};