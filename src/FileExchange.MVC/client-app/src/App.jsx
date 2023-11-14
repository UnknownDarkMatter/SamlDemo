import './App.scss';
import React from 'react';
import MainPageComponent from './pages/MainPage/MainPageComponent';
import { useEffect } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';

const App = () => {

    useEffect(() => {
        axios(`${process.env.REACT_APP_BACKEND_BASE_URL}Auth/IsAuthenticated`)
        .then((response: AxiosResponse) => {
            if (response.status == 302) {
                window.location.href = `${process.env.REACT_APP_BACKEND_BASE_URL}Auth/Login`;
            }
        }).catch((error:AxiosError) => {
            console.log(error.response.status);
            if (error.response.status == 302) {
                window.location.href = `${process.env.REACT_APP_BACKEND_BASE_URL}Auth/Login`;
            }
        })
        
    }, []);

    const logOut = () => {
        axios(`${process.env.REACT_APP_BACKEND_BASE_URL}Auth/Logout`).then(() => {
            window.location.reload();
        });
    };
 
  return (
      <div class="app">
          <button onClick={logOut}>Logout</button>
          <br/>
          <MainPageComponent></MainPageComponent>
    </div>
  );
}

export default App;
