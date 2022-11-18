pipeline
{
	agent {label 'jenkins-slave-1'}
	environment
	{
		DOCKERHUB_CREDENTIALS = credentials('dockerhub')
	}
	stages
	{
		stage('gitclone')
		{
			steps
			{
				git 'https://github.com/Psp29/app-api-nginx.git'
			}
		}
		stage('Login')
		{
			steps
			{
				sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
			}
		}
		stage('Build')
		{
			steps
			{
				sh 'docker-compose build --pull'
			}
		}
		stage('Push')
		{
			steps
			{
				sh 'docker-compose push'
			}
		}
		// stage('Pull')
		// {
		// 	steps
		// 	{
		// 		sh 'docker pull psp29/jenkinsassignment2:latest'
		// 	}
		// }
		stage('Deploy')
		{
			steps
			{
				sh 'docker-compose up'
			}
		}
	}
post
	{
		always
		{
			sh 'docker logout'
		}
	}
}
