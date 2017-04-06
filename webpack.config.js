var debug = process.env.NODE_ENV !== "production";
var webpack = require('webpack');


module.exports = {
  devtool: debug ? 'source-map' : null,
  entry: {
    main: './Scripts/main.js'
  },
  module: {
    loaders: [
        {
          test: /\.js?$/,
          exclude: /(node_modules|bower_components)/,
          loader: 'babel-loader'
        }
    ]
  },
  output: {
    filename: debug ? './dist/scripts/[name].js' : './dist/scripts/[name].min.js'
  },
  plugins: debug ? [] : [
    new webpack.optimize.DedupePlugin(),
    new webpack.optimize.OccurenceOrderPlugin(),
    new webpack.optimize.UglifyJsPlugin({mangle:false, sourceMap: false})
  ]
};