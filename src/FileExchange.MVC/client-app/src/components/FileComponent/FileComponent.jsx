import React from 'react';
import './FileComponent.scss';
import { BsFileEarmark } from 'react-icons/bs';
import { AiFillDelete } from 'react-icons/ai';
import {  useDispatch } from 'react-redux';
import {  fetchFilesDataThunk } from '../../redux-resource/file-reducer';
import { deleteFileFromApi } from '../../services/file-service';

const FileComponent = (props) => {
       const dispatch = useDispatch();
       const deleteFile = (id) => {
              deleteFileFromApi(id).then(()=> {
                     dispatch(fetchFilesDataThunk());
              });
	};

       return (
              <div class="wrapper">
                     <div class="content">
                            <div class="line">
                                   <BsFileEarmark size={30} />
                                   <div class="file-name">{props.file.friendlyName }</div>
                                   <AiFillDelete size={30} onClick={e => deleteFile(props.file.id)}></AiFillDelete>
                            </div>
                     </div>
              </div>
       );
     }
export default FileComponent;