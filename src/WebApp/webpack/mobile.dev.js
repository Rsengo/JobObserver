const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const FaviconsWebpackPlugin = require('favicons-webpack-plugin');
const { BundleAnalyzerPlugin } = require('webpack-bundle-analyzer');
const webpack = require('webpack');

const PATHS = {
  src: path.resolve(__dirname, '..', 'src'),
  dist: path.resolve(__dirname, 'dist'),
};

module.exports = () => ({
  entry: `${PATHS.src}/indexDesktop.js`,
  output: {
    path: PATHS.dist,
    filename: 'bundle.[hash].js',
  },
  devtool: 'source-map',
  module: {
    rules: [
      {
        test: /\.js|.jsx?$/,
        exclude: /(node_modules)/,
        loaders: ['babel-loader'],
      },
      {
        test: /\.scss$/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: 'css-loader',
          },
          {
            loader: 'postcss-loader',
            options: {
              config: {
                path: 'postcss.config.js',
              },
            },
          },
          'sass-loader',
        ],
        exclude: /(node_modules)/,
      },
      {
        test: /\.css$/,
        use: [
          MiniCssExtractPlugin.loader,
          'css-loader',
        ],
      },
      { test: /\.xml$/, loader: 'xml-loader' },
      {
        test: /\.(jpe?g|png|gif)$/i,
        use: [{
          loader: 'url-loader',
          options: {
            limit: 10000,
            name: 'assets/[name].[ext]',
          },
        }],
      },
      {
        test: /\.svg$/,
        loader: 'svg-inline-loader',
      },
      {
        test: /\.(woff(2)?|ttf|eot)(\?v=\d+\.\d+\.\d+)?$/,
        use: [{
          loader: 'file-loader',
          options: {
            name: '[name].[ext]',
            outputPath: 'assets/fonts/',
          },
        }],
      },
    ],
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: 'main.[hash].css',
    }),
    new HtmlWebpackPlugin({
      template: `${PATHS.src}/assets/index.html`,
    }),
    new FaviconsWebpackPlugin('assets/favicon.png'),
    new webpack.EnvironmentPlugin({ NODE_ENV: 'development' }),
    // new BundleAnalyzerPlugin(),
  ],
  resolve: {
    modules: ['node_modules', path.resolve(__dirname, '..', 'src')],
    extensions: ['.js', '.json', '.jsx', '.css'],
  },
  devServer: {
    port: 8000,
    stats: 'errors-only',
    publicPath: '/',
    historyApiFallback: true,
  },
  optimization: {
    runtimeChunk: {
      name: 'manifest',
    },
    splitChunks: {
      minSize: 1,
      chunks: 'all',
      cacheGroups: {
        vendor: {
          test: /[\\/]node_modules[\\/]/,
          name: 'vendors',
          priority: -20,
          chunks: 'all',
        },
      },
    },
    namedChunks: true,
  },
});