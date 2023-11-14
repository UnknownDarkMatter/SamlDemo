import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import  {getFilesFromApi} from '../services/file-service';

const defaultFileList = [];

const initialState = {
  data: defaultFileList,
  loading: false,
  error: false,
};

export const fetchFilesDataThunk = createAsyncThunk('files/getAll', async (_, thunkApi) => {
	  const response = await getFilesFromApi();
	  //thunkApi.dispatch(getFiles(response.data, GET_FILES));
	  return response.data;
});

export const filesSlice = createSlice({
  name: 'files',
  initialState,
  reducers: {
    getFiles: (state = defaultFileList, action) => {
		return [...state, action.payload]
		},
	},
	extraReducers: (builder) => {
		builder
		.addCase(fetchFilesDataThunk.fulfilled, (state, action) => {
			state.status = 'succeeded';
			state.data = action.payload;
		});
	},
});

// Actions
export const { getFiles } = filesSlice.actions;

// Selector
export const getFileSlice = (state) => state.file;

// Reducer
const FilesReducer = filesSlice.reducer;

export default FilesReducer;