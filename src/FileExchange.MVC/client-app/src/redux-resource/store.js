import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import FilesReducer from './file-reducer'


const customizedMiddleware = getDefaultMiddleware({
  serializableCheck: false
})

export default configureStore({
    reducer: {
      files: FilesReducer,
    },
    middleware:customizedMiddleware
  });