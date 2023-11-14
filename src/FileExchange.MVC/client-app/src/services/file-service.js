import  axios from 'axios';
import { FileDto} from '../model/file-dto';

export const getFilesFromApi = () => {
    return axios(`${process.env.REACT_APP_BACKEND_BASE_URL}File/GetAll`);
}

export const createFileFromApi = (file:FileDto) => {
    return axios.post(`${process.env.REACT_APP_BACKEND_BASE_URL}File/Create`, file);
}

export const deleteFileFromApi = (id:number) => {
    return axios.delete(`${process.env.REACT_APP_BACKEND_BASE_URL}File/Delete?id=${id}`);
}